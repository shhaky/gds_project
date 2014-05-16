
package nl.fontys.cryptoexchange.webservice;

import java.util.List;

import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;
import nl.fontys.cryptoexchange.webservice.response.Response;

/** Example resource class hosted at the URI path "/myresource"
 */
@Path("/marketdata")
public class MarketDataResource {
    
    /** Method processing HTTP GET requests, producing "text/plain" MIME media
     * type.
     * @return String that will be send back as a response of type "t ext/plain".
     */
	
    
    
    @PUT
    @Produces(MediaType.APPLICATION_JSON)
    public Response<List<Order>> getAksDepth(String param) {
       
    	Response<List<Order>> response = null;
    	
    	System.out.println(param);
    	
		try {
			response = new Response<List<Order>>(TradeEngineHolder.getTradeEngine().getAskDepth(param));
			response.setSuccsess();
		} catch (MarketNotAvailableException e) {
			
			response = new Response<List<Order>>();
			response.setFail(e.getClass().getSimpleName());
		}
    	
    	return response;
    }
}
