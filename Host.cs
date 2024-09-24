public class Host {
    public float realClock {get;set;} = 0 ;
    public float virtualClock {get;set;} = 0;

    public Host(int realClockValue)
    {
        realClock = realClockValue;
        virtualClock = realClock;
    }
    public void addASecondToRealClock(){
        realClock+= 1;
    }

    public void addASecondToVirtualClock(){
        virtualClock+= 1;
    }

}



