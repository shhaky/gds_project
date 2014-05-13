
package nl.fotnys.cryptoexchange.webservice;

import java.math.BigDecimal;

import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;


import nl.fontys.cryptoexchange.core.BuyOrder;
import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;


/** Example resource class hosted at the URI path "/myresource"
 */
@Path("/myresource")
public class MyResource {
    
    /** Method processing HTTP GET requests, producing "text/plain" MIME media
     * type.
     * @return String that will be send back as a response of type "text/plain".
     */
    @GET 
    @Produces(MediaType.APPLICATION_JSON)
    public Order getIt() {
        
    	BuyOrder order  = new BuyOrder(CurrencyPair.DOGE_BTC,54645, BigDecimal.ONE,BigDecimal.TEN,5346454);
    	
    	
    	return order;
    }
    
    @GET 
    @Path ("tobi")
    @Produces("text/plain")
    public String getTobi( @QueryParam("name") String  name) {
        return "hallo " + name;
    }
    
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public String putExample(Sample sample)
    {
    	
    	System.out.println("PUT "+sample);
			return null;
    	
    }
    
}
