package nl.fontys.cyrptoexchange.engine.marketdata;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Observable;
import java.util.Observer;
import java.util.Queue;

import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.engine.TemporaryTradeHistory;

public class Average implements Observer {
	
	private double movingAverage;
	private int volume;
	private int timeIntervalInMinutes;
	private ArrayList<Trade> tradeHistory;
	private Queue<Trade> averageQueue;
	
	public Average(TemporaryTradeHistory history, int timeIntervalInMinutes) {
		this.timeIntervalInMinutes = timeIntervalInMinutes;
		history.addObserver(this);
		this.tradeHistory = history.getList();
		this.averageQueue = new LinkedList<Trade>();
		 
		
	}
	
	private Queue<Trade> getQueueValues(){
		
		Calendar endTime = Calendar.getInstance();
		endTime.setTime(tradeHistory.get(tradeHistory.size()-1).getTimeStamp());
		endTime.add(Calendar.MINUTE, -timeIntervalInMinutes);
		
		for(int i = 0; i < tradeHistory.size(); i++){
			if(tradeHistory.get(i).getTimeStamp().compareTo(endTime.getTime()) >= 0){
				averageQueue.add(tradeHistory.get(i));
				
			}
		}
		
		return averageQueue;
		
	}
	
	
	public double getMovingAverage(){
		
		getQueueValues();
		
		double average = 0;
		
		for(Trade trade : averageQueue ){
				average += trade.getPrice().doubleValue();
				
		}
		
		movingAverage = average/averageQueue.size();
		
		return movingAverage;
	}
	
	public int getMarketVolume(){
		
		getQueueValues();
		volume =averageQueue.size();
		
		return volume;
		
	}
	
	
	public int getInterval(){
		return timeIntervalInMinutes;
	}
	
	public String toString(){
		return ("The moving average for the past " + timeIntervalInMinutes + " minutes is " + movingAverage
					+ ". The Market Volume is " + volume);
	}


	@Override
	public void update(Observable o, Object data) {
		
		@SuppressWarnings("unchecked")
		HashMap<String, Object> push = (HashMap<String, Object>) data;
		
		Trade newIncomingTrade = (Trade) push.get("trade");
		
		this.tradeHistory.add(newIncomingTrade);
		
		
		
		
	}

}
