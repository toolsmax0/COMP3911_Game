using System.Collections;
public class Settings
{
    //using singleton pattern
    private static Settings instance;
    public Hashtable settings;
    Settings()
    {
        settings = new Hashtable();
        //default value
        settings.Add("jumpqueue", false);
        settings.Add("randomMoney", false);
    }
    public static Settings getInstance()
    {
        if (instance == null)
        {
            instance = new Settings();
        }
        return instance;
    }

    public void ToggleJumpQueue()
    {

        settings["jumpqueue"] = !(bool)settings["jumpqueue"];
    }

    public bool CanJumpQueue()
    {
        return (bool)settings["jumpqueue"];
    }

    public void ToggleRandomMoney()
    {
        settings["randomMoney"] = !(bool)settings["randomMoney"];
    }

    public bool CanRandomMoney()
    {
        return (bool)settings["randomMoney"];
    }
}