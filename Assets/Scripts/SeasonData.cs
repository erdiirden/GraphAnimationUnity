using System;
using System.Collections.Generic;

[Serializable]
public class Cup
{
    public string name;
    public string winner;
}

[Serializable]
public class Season
{
    public int season;
    public List<Cup> cups;
}

[Serializable]
public class SeasonData
{
    public List<Season> seasons;
}
