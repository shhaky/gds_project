package nl.fontys.cryptoexchange.core;

/**
 * @author  Tobias Zobrist
 * @version 1.0
 * @created 15-Apr-2014 03:49:28
 * 
 * represents a CurrencyPair witch is traded on the platform
 * 
 * 
 */
public class CurrencyPair {

	// Provide some default BTC major symbols
	  public static final CurrencyPair LTC_BTC = new CurrencyPair(Currency.LTC, Currency.BTC);
	  public static final CurrencyPair PPC_BTC = new CurrencyPair(Currency.PPC,Currency.BTC);
	  public static final CurrencyPair DOGE_BTC = new CurrencyPair(Currency.DOGE, Currency.BTC);
	  public static final CurrencyPair ZET_BTC = new CurrencyPair(Currency.ZET, Currency.BTC);
	  public static final CurrencyPair NXT_BTC= new CurrencyPair(Currency.NXT, Currency.BTC);
	  public static final CurrencyPair TRC_BTC = new CurrencyPair(Currency.TRC, Currency.BTC);
	
	
	/**
	 * this will create a new Currency pair. I f base symbol not specified BTC will be taken
	 * @param counterSymbol 
	 */
	public CurrencyPair(Currency counterSymbol)
	{
		this.counterSymbol = counterSymbol;
		this.baseSymbol = Currency.BTC;
	}
	
	/**
	 * this will create a new Currency pair. I f base symbol not specified BTC will be taken
	 * @param counterSymbol 
	 */
public CurrencyPair(Currency counterSymbol, Currency baseSymbol) {
	
	this.baseSymbol = baseSymbol;
	this.counterSymbol = counterSymbol;
}
	
	
	

	public Currency getBaseSymbol(){
		return this.baseSymbol;
	}

	public Currency getCounterSymbol(){
		return this.counterSymbol;
	}



	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result
				+ ((baseSymbol == null) ? 0 : baseSymbol.hashCode());
		result = prime * result
				+ ((counterSymbol == null) ? 0 : counterSymbol.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		CurrencyPair other = (CurrencyPair) obj;
		if (baseSymbol != other.baseSymbol)
			return false;
		if (counterSymbol != other.counterSymbol)
			return false;
		return true;
	}

	@Override
	public String toString(){
		return counterSymbol +"/" + baseSymbol;
	}

	private final Currency baseSymbol;
	private final Currency counterSymbol;
}