package nl.fontys.cryptoexchange.core;

public class TradeIdGenerator {

	//TODO implement it
	public long getTradeId()
	{
		return 323243;
	}
	
	//TODO implement it in a Thread safe way
	public static TradeIdGenerator getInstance()
	{
		if(instance == null)
		{
			instance = new TradeIdGenerator();
		}
		
		return instance;
	}


	private static TradeIdGenerator instance;
	private TradeIdGenerator() {
	}
	
	
	
	
}
