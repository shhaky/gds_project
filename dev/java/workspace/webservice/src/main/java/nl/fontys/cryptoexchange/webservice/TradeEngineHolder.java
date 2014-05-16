package nl.fontys.cryptoexchange.webservice;

import nl.fontys.cryptoexchange.engine.TradeEngine;
import nl.fontys.cryptoexchange.engine.TradeEngineManualUpdating;


import com.sun.jersey.spi.resource.Singleton;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 16-Apr-2014 02:14 Holder for the Trade Engine instance -- Singleton
 */

@Singleton
public class TradeEngineHolder {

	private static TradeEngine instance;

	public static synchronized TradeEngine getTradeEngine() {
		if (instance == null) {
			instance = new TradeEngineManualUpdating();
		}
		return instance;
	}

	/**
	 * Don't use only for JUNIT test purpose!
	 */
	@Deprecated
	public void TEST_RESET() {

		instance = new TradeEngineManualUpdating();

	}

}
