using ElectronicDevice.ElectronicDevices.Chargers;
using ElectronicDevice.Exceptions.PortableDeviceException;

namespace ElectronicDevice.ElectronicDevices.PortableDevices;

public abstract class PortableDeviceBase : ElectronicDeviceBase
{
    protected readonly List<ChargerBase> PossibleChargers;
    private ChargerBase? _currentCharger;
    private bool _pluggedIn;
    private double _currentBatteryUsage;
    private Task? _batteryRunOut;
    private CancellationTokenSource? _currentBatteryRunOutCts;

    protected PortableDeviceBase(double power, string name) : base(power, name)
    {
        PossibleChargers = new List<ChargerBase>();
    }

    public double CurrentCharge { get; private set; } = 100;

    public override bool PluggedIn
    {
        get => _pluggedIn;
        set
        {
            _pluggedIn = value;
            if (value)
            {
                StartCharge();
                return;
            }

            EndCharge();
        }
    }

    public virtual void AddCharger(ChargerBase charger)
    {
        PossibleChargers.Add(charger);
    }

    protected abstract double DefaultBatteryUsage { get; }

    protected abstract double TurnedOffBatteryUsage { get; }

    public override void TurnOff()
    {
        _currentBatteryUsage = DefaultBatteryUsage;
        RefreshBatteryUsageTask();
    }

    public override void TurnOn()
    {
        if (CurrentCharge <= 0)
        {
            throw new DeadBatteryTurnOnException();
        }

        _currentBatteryUsage = TurnedOffBatteryUsage;
        RefreshBatteryUsageTask();
    }

    public void StartCharge()
    {
        _currentCharger = FindBestCharger() ?? throw new NoAvailableChargersFoundException();
        _currentCharger.IsInUseNow = true;
    }

    public void EndCharge()
    {
        _currentCharger!.IsInUseNow = false;
        _currentCharger = null;
        CurrentCharge = 0;
    }

    protected abstract ChargerBase? FindBestCharger();

    private void RefreshBatteryUsageTask()
    {
        if (_currentBatteryRunOutCts is not null)
        {
            try
            {
                _currentBatteryRunOutCts.Cancel();
            }
            catch (TaskCanceledException)
            {
                // cannot kill thead without causing an exception
            }
        }

        _currentBatteryRunOutCts = new CancellationTokenSource();
        var runoutSpeed = _currentBatteryUsage - (_currentCharger?.Power ?? 0);

        _batteryRunOut = Task.Run(() =>
        {
            while (!_currentBatteryRunOutCts.IsCancellationRequested)
            {
                CurrentCharge -= runoutSpeed;
                CurrentCharge = CurrentCharge switch
                {
                    < 0 => 0,
                    > 100 => 100,
                    _ => CurrentCharge
                };

                Console.WriteLine(CurrentCharge);
                Thread.Sleep(20000);
            }
        }, _currentBatteryRunOutCts.Token);
    }
}