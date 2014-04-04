package nl.fontys.cryptoexchange.core;

/**
 * @author Ratidzo Zvirawa, Tobias Zobrist
 * @version 1.0
 * @created 04-Apr-2014 14:05:28
 */
public class CurrencyPair {

	private final Currency baseSymbol;
	private final Currency counterSymbol;

	
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
	public void finalize() throws Throwable {

	}
	/**
	 * override existing!
	 * 
	 * @param currencyPair
	 */
	public boolean equals(CurrencyPair currencyPair){
		return false;
	}

	public Currency getBaseSymbol(){
		return null;
	}

	public Currency getCounterSymbol(){
		return null;
	}

	/**
	 * override this because we have equals! HashMaps or whatever need this!
	 */
	public int hashcode(){
		return 0;
	}

	/**
	 * override existing!
	 */
	public String toString(){
		return "";
	}
}//end CurrencyPair