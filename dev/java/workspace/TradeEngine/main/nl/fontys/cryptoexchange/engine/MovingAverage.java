package nl.fontys.cryptoexchange.engine;

import java.util.Date;

public class MovingAverage {
	
	private int movingAverage;
	private int interval;
	private Date timeOfAverage;
	
	public MovingAverage(int movingAverage, int interval, Date timeOfAverage){
		this.movingAverage = movingAverage;
		this.interval = interval;
		this.timeOfAverage = timeOfAverage;
		
	}
	
	public int getMovingAverage(){
		return movingAverage;
	}
	
	public int getInterval(){
		return interval;
	}
	
	public Date getTimeOfAverage(){
		return timeOfAverage;
	}
	
	public String toString(){
		return ("The moving average of " + movingAverage + " at the time of " 
				+ timeOfAverage + " with the interval of " + interval + "minute(s)");
	}

}
