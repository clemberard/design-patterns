public interface ICommand
{
    void Execute();
    void Undo();
}

public class HomeAutomationFacadeCommand : ICommand
{
    private readonly HomeAutomationFacade _facade;
    private readonly string _mode;
    
    public HomeAutomationFacadeCommand(HomeAutomationFacade facade, string mode)
    {
        _facade = facade;
        _mode = mode;
    }
    
    public void Execute()
    {
        if (_mode == "Cinema")
        {
            _facade.CinemaMode();
        }
        else if (_mode == "Home")
        {
            _facade.LeavingHomeMode();
        }
    }

    public void Undo()
    {
        if (_mode == "Cinema")
        {
            _facade.ExitCinemaMode();
        }
        else if (_mode == "Home")
        {
            _facade.ArrivingHomeMode();
        }
    }
}

public class HomeAutomationFacade
{
    private readonly Lights _lights;
    private readonly Thermostat _thermostat;
    private readonly Shutters _shutters;
    private readonly MusicPlayer _musicPlayer;
    private readonly TV _tv;
    
    public HomeAutomationFacade()
    {
        _lights = new Lights();
        _thermostat = new Thermostat();
        _shutters = new Shutters();
        _musicPlayer = new MusicPlayer();
        _tv = new TV();
    }
    
    // Scénario complexe simplifié : mode cinéma
    public void CinemaMode()
    {
        _shutters.Close();
        _lights.TurnOff();
        _tv.TurnOn();
    }

    // Scénario inverse du mode cinéma
    public void ExitCinemaMode()
    {
        _shutters.Open();
        _lights.TurnOn();
        _tv.TurnOff();
    }

    // Scénario complexe simplifié : mode départ
    public void LeavingHomeMode()
    {
        _lights.TurnOff();
        _thermostat.SetAwayMode();
        _shutters.Close();
        _musicPlayer.Stop();
        _tv.TurnOff();  
    }

    // Scénario inverse du mode départ
    public void ArrivingHomeMode()
    {
        _lights.TurnOn();
        _thermostat.SetComfortMode();
        _shutters.Open();
        _musicPlayer.Play();
        _tv.TurnOn();  
    }
}

public class Lights
{
    public void TurnOn() => Console.WriteLine("Lights ON");
    public void TurnOff() => Console.WriteLine("Lights OFF");
    public void Dim(int level) => 
        Console.WriteLine($"Lights DIMMED to {level}%");
}

public class Thermostat
{
    public void SetTemperature(int celsius) => 
        Console.WriteLine($"Temperature set to {celsius}°C");
    public void SetAwayMode() => Console.WriteLine("Thermostat in away mode");
    public void SetComfortMode() => Console.WriteLine("Thermostat in comfort mode");
}

public class Shutters
{
    public void Open() => Console.WriteLine("Shutters OPEN");
    public void Close() => Console.WriteLine("Shutters CLOSED");
    public void SetPosition(int percentage) => 
        Console.WriteLine($"Shutters set to {percentage}% open");
}

public class MusicPlayer
{
    public void Play() => 
        Console.WriteLine("Music PLAYING");
    public void Stop() => Console.WriteLine("Music STOPPED");
    public void SetVolume(int level) => 
        Console.WriteLine($"Music volume set to {level}");
}

public class TV
{
    public void TurnOn() => Console.WriteLine("TV ON");
    public void TurnOff() => Console.WriteLine("TV OFF");
    public void SetChannel(int channel) => 
        Console.WriteLine($"TV channel set to {channel}");
}

namespace Tp5
{
    public class FacadeDemo
    {
        public static void Run(string[] args)
        {
            HomeAutomationFacade facade = new HomeAutomationFacade();
            ICommand cinemaCommand = new HomeAutomationFacadeCommand(facade, "Cinema");
            ICommand homeCommand = new HomeAutomationFacadeCommand(facade, "Home");

            Console.WriteLine("Activating Cinema Mode:");
            cinemaCommand.Execute();

            Console.WriteLine("\nDesactivating Cinema Mode:");
            cinemaCommand.Undo();

            Console.WriteLine("\nActivating Leaving Home Mode:");
            homeCommand.Execute();

            Console.WriteLine("\nDesactivating Leaving Home Mode:");
            homeCommand.Undo();

            Console.WriteLine("\nCustom Settings:");
            Lights lights = new Lights();
            lights.Dim(50);
            Thermostat thermostat = new Thermostat();
            thermostat.SetTemperature(22);
            Shutters shutters = new Shutters();
            shutters.SetPosition(75);
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetVolume(30);
            TV tv = new TV();
            tv.SetChannel(5);
        }
    }
}