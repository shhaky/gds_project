package nl.fotnys.cryptoexchange.webservice;

import nl.fontys.cryptoexchange.engine.TradeEngine;
import nl.fontys.cryptoexchange.engine.TradeEngineManualUpdating;

public class EngineHolder {

	private static TradeEngineManualUpdating instance;

	public static synchronized TradeEngine getInstance() {
		if (instance == null) {
			instance = new TradeEngineManualUpdating();
		}
		return instance;
	}
}
