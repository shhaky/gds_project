package nl.fontys.cryptoexchange.engine;

import java.util.ArrayList;
import java.util.Calendar;

import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBook;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookArrayList;

public class MovingAverageCalculation {
	
	private ArrayList<Trade> tradeHistory;
	private Trade firstTrade;
	private OrderBook orderbook;
	private int interval;
	private MovingAverage movingAverage;
	private ArrayList<MovingAverage> movingAverageList;
	
	public MovingAverageCalculation(OrderBookArrayList orderBook, int interval){
		
		this.tradeHistory = orderBook.getTradeHistory().getList();
		this.interval = interval;
	}
	
	/**
	 * Calculates the moving average of the trades in the trade history according to 
	 * the interval entered by user
	 * @return list of moving averages
	 */
	public ArrayList<MovingAverage> getMovingAverage()
	{
		int average = 0;
		int count = 0;
		int total = 0;
		int x = 0;
		firstTrade = tradeHistory.get(x);
		firstTrade.getTimeStamp();
		
		while(x < tradeHistory.size() ){
			
		Calendar endTime = Calendar.getInstance();
		endTime.setTime(tradeHistory.get(x).getTimeStamp());
		endTime.add(Calendar.MINUTE, interval);
		
			for(int i = x; i < tradeHistory.size(); i++)
			{
				if(tradeHistory.get(i).getTimeStamp().compareTo(endTime.getTime()) <= 0)
				{
					total += tradeHistory.get(i).getPrice().intValue();
					count++;
				}
			}
		
			if(count >0)
			{
				average = total/count;
				movingAverage = new MovingAverage(average, interval, endTime.getTime());
				movingAverageList.add(movingAverage);
		
			}
		
			count = 0;
			x ++;
		
		
		}
		
		return movingAverageList;
	}

}
