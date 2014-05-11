package nl.fontys.cryptoexchange.engine;

import java.math.BigDecimal;
import java.util.Date;
import java.util.HashMap;
import java.util.Observable;
import java.util.Observer;

import nl.fontys.cryptoexchange.core.Trade;

public class MovingAverage implements Observer {
	
	private int movingAverage;
	private int interval;
	private Date timeOfAverage;
	
	
	public MovingAverage(long timeIntervalInMinutes, TemporaryTradeHistory history) {
		
		history.addObserver(this);
		
	}
	
	
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


	@Override
	public void update(Observable o, Object data) {
		
		@SuppressWarnings("unchecked")
		HashMap<String, Object> push = (HashMap<String, Object>) data;
		
		Trade newIncomingTrade = (Trade) push.get("trade");
		
		
		
		
	}

}
