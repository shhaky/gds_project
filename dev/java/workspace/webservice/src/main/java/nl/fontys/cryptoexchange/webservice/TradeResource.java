package nl.fontys.cryptoexchange.webservice;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;



@Path("/trade")
public class TradeResource {
	 @GET 
	    @Path("/theansweroflife")
	    @Produces("text/plain")
	    public String easterEgg() {
	        return "42";
	    }
}
