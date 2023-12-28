namespace TLVLibrary;

public static class Misc
{
    /// <summary>
    /// Takes a DateTime value and transforms it into a cron expression
    /// </summary>
    /// <param name="datetime">The DateTime.</param>
    /// <returns>Cron Expression&gt;</returns>
    public static string DateTimeToCronString(DateTime datetime)
    {
        string cronSchedule = $"0 {datetime.Minute} {datetime.Hour} ? * {(int)datetime.DayOfWeek + 1}";

        return cronSchedule;
    }

    /// <summary>
    /// Checks if runtime environment is debug or release
    /// </summary>
    /// <returns>true or false</returns>
    public static bool IsDebug() //Preprocessor hacks
    {
#if DEBUG
        return true;
#else
        return false;
#endif
    }
}