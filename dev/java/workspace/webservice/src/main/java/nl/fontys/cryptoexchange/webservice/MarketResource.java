package nl.fontys.cryptoexchange.webservice;


import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import nl.fontys.cryptoexchange.core.exception.InvalidCurrencyPairException;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;
import nl.fontys.cryptoexchange.webservice.response.Response;

@Path("/market")
public class MarketResource {
	  	
	
		@SuppressWarnings("rawtypes")
		@Path("/create")
	    @Produces(MediaType.APPLICATION_JSON)
		@Consumes(MediaType.TEXT_PLAIN)
		@PUT
	    public Response createMarket(String param) {
			Response response = new Response();
				try {
					TradeEngineHolder.getTradeEngine().createMarket(param);
					response.setSuccsess();
				} catch (InvalidCurrencyPairException e) {
					response.setFail(e.getClass().getSimpleName());
				}
	    	return response;
	    }
		
		
		@SuppressWarnings("rawtypes")
		@Path("/remove")
	    @Produces(MediaType.APPLICATION_JSON)
		@Consumes(MediaType.TEXT_PLAIN)
		@PUT
	    public Response removeMarket(String param) {
			Response response = new Response();
			
				try {
					TradeEngineHolder.getTradeEngine().removeMarket(param);
					response.setSuccsess();
				} catch (MarketNotAvailableException e) {
					response.setFail(e.getClass().getSimpleName());
				}
	    	return response;
	    }
}
