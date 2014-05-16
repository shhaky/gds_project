package nl.fontys.cryptoexchange.core;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlRootElement;

import nl.fontys.cryptoexchange.core.exception.InvalidCurrencyPairException;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 15-Apr-2014 03:49:28 represents a CurrencyPair witch is traded on
 *          the platform
 */
@XmlRootElement
public class CurrencyPair {

	// Provide some default BTC major symbols
	public static final CurrencyPair LTC_BTC = new CurrencyPair("LTC", "BTC");

	public static final CurrencyPair PPC_BTC = new CurrencyPair("PPC", "BTC");

	public static final CurrencyPair DOGE_BTC = new CurrencyPair("DOGE", "BTC");

	public static final CurrencyPair ZET_BTC = new CurrencyPair("ZET", ".BTC");

	public static final CurrencyPair NXT_BTC = new CurrencyPair("NXT", "BTC");

	public static final CurrencyPair TRC_BTC = new CurrencyPair("TRC", "BTC");

	/**
	 * this will create a new Currency pair. I f base symbol not specified BTC
	 * will be taken
	 * 
	 * @param counterSymbol
	 * @throws InvalidCurrencyPairException 
	 */
	public CurrencyPair(String pair) throws InvalidCurrencyPairException {
		
		try{
		this.counterSymbol = pair.split("/")[0].toUpperCase();
		this.baseSymbol = pair.split("/")[1].toUpperCase();
		}
		catch(Exception e){
			throw new InvalidCurrencyPairException(pair);
		}
	}

	/**
	 * this will create a new Currency pair. I f base symbol not specified BTC
	 * will be taken
	 * 
	 * @param counterSymbol
	 */
	public CurrencyPair(String counterSymbol, String baseSymbol) {

		this.baseSymbol = baseSymbol.toUpperCase();
		this.counterSymbol = counterSymbol.toUpperCase();
	}
	

	/**
	 * used by XML Mapper
	 */
	public CurrencyPair() {
	}
	
	@XmlAttribute
	public String getBaseSymbol() {
		return this.baseSymbol;
	}
	@XmlAttribute
	public String getCounterSymbol() {
		return this.counterSymbol;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((baseSymbol == null) ? 0 : baseSymbol.hashCode());
		result = prime * result + ((counterSymbol == null) ? 0 : counterSymbol.hashCode());
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
		if (!baseSymbol.equals(other.baseSymbol))
			return false;
		if (!counterSymbol.equals(other.counterSymbol))
			return false;
		return true;
	}

	@XmlAttribute
	@Override
	public String toString() {
		return counterSymbol + "/" + baseSymbol;
	}

	private  String baseSymbol;

	private String counterSymbol;
}