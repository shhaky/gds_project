package nl.fontys.cryptoexchange.engine;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.Observable;
import java.util.Observer;

import org.apache.log4j.Logger;

import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderType;

/**
 * <ul>
 * 	<li>Here are all the pending orders stored. This class has to be able to sort
 * its own elements when you add them</li>
 * </ul>
 * <ul>
 * 	<li>The orderbook has a sorted Vector inside it will put the new Orders into
 * the correct positon of the stack</li>
 * </ul>
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 16-Apr-2014 01:58
 */
public abstract class OrderBook  {
	
	public OrderBook(){
		
		this.list = new ArrayList<Order>();
	}
	
	/**
	 * this will put the Order in the right order of the list by doing a binary search
	 * or maybe top down search depends on performance... 
	 * 
	 * @param order
	 * @return 
	 */
	public boolean add(Order order){
		
		
		
		if(this.list.isEmpty())
		{
			log.trace("new order added at Position " + 0);
			this.list.add(order);
		}
		else
		{
		Iterator<Order> iterator = list.iterator();
		
		int arrayAddPosition = 0;
		while(iterator.hasNext())
		{
			//multiply it with bidAskModifier to sort it depending on BID or ASK
			int value =  bidAskModifier * iterator.next().compareTo(order);
			if(value == 1)
			{
				this.list.add(arrayAddPosition, order);
				log.trace("new order added at Position " + arrayAddPosition);
				return true;
			}
			arrayAddPosition++;
		}
		
		//add on last position
		this.list.add(arrayAddPosition, order);
		log.trace("new order added at Position " + arrayAddPosition);
		return true;
		
	}
		return false;
	}

	/**
	 * this will remove the best Offer
	 * 
	 * has to be synchronized!
	 */
	public Order getBestOffer(){
		
		Order bestOrder = list.get(0);
		list.remove(0);
		
		log.trace("Best Offer removed");
		return bestOrder;
	}

	/**
	 * this will not remove the offer from the list
	 * 
	 * has to be synchronized
	 */
	public Order peekBestOffer(){
		return list.get(0);
	}
	
	@Override
	public String toString()
	{
		return this.list.toString();
	}

	private Logger log = Logger.getLogger(OrderBook.class);

	public ArrayList<Order> list;
	
	
	//will modify the comparator value that Orders of a BidOrderbook are sorted the opposite way than in a AskOrderbook
	protected int bidAskModifier;

	/**
	 * modifier to sort the list top down
	 */
	protected static int BID = 1;
	/**
	 * modifier to sort the list bottom up
	 */
	protected static int ASK = -1;
	
	

	
}
