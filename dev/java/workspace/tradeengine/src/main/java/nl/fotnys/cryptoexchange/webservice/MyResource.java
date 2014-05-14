
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



@Path("/tre")
public class MyResource {
    
    /** Method processing HTTP GET requests, producing "text/plain" MIME media
     * type.
     * @return String that will be send back as a response of type "text/plain".
     */
    //here I had to use a workaround because Order has final attributes and also does not have a non arg Construcor I decided to cast it to JSON with the method toJson
    //If I would have done it with MediaType.APPLICATION_JSON I needed to create multiple adapter classes

    @GET 
    @Produces("text/plain")
    public String getIt() {
        
    	BuyOrder order  = new BuyOrder(CurrencyPair.DOGE_BTC,54645, BigDecimal.ONE,BigDecimal.TEN,5346454);
    	
    	
    	return order.toJson();
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
//    
}
