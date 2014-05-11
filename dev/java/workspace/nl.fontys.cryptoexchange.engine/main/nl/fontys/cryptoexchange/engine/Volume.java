package nl.fontys.cryptoexchange.engine;

import java.util.ArrayList;
import java.util.Calendar;

import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBook;
import nl.fontys.cryptoexchange.engine.orderbook.OrderBookArrayList;
/**
 * 
 * @author Ratidzo Zvirawa
 *
 */
public class Volume {
	
	private OrderBook orderbook;
	private int interval;
	private ArrayList<Trade> tradeHistory;
	
	public Volume(OrderBook orderbook, int interval){
		this.orderbook = orderbook;
		this.interval = interval * -1;
		this.tradeHistory = orderbook.getTradeHistory().getList();
		
	}
	
	public int getVolume(){
		int volume = 0;
		
		Calendar endTime = Calendar.getInstance();
		endTime.setTime(tradeHistory.get(tradeHistory.size()-1).getTimeStamp());
		endTime.add(Calendar.MINUTE, interval);
		
		for(int i = 0; i < tradeHistory.size(); i++ ){
			
			if(tradeHistory.get(i).getTimeStamp().compareTo(endTime.getTime()) >= 0){
				volume++;
			}
		}
		
		return volume;
	}

}
