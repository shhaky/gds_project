package nl.fotnys.cryptoexchange.webservice;

import java.math.BigDecimal;
import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.engine.TradeEngine;
import nl.fontys.cryptoexchange.engine.TradeEngineManualUpdating;

@Path("/marketdata")
public class MarketData {

	
	
	 	@GET 
	 	@Path("/getmarkets")
	    @Produces(MediaType.APPLICATION_JSON)
	    public List<CurrencyPair> getIt() {
	 		
	 		TradeEngine engine = EngineHolder.getInstance();
	    	
	    	return engine.getMarkets();
	    }
	
	
}
