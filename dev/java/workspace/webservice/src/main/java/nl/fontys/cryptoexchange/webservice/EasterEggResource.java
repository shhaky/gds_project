package nl.fontys.cryptoexchange.webservice;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;


@Path("/theansweroflife")
public class EasterEggResource {
	
	
	@GET 
    @Produces("text/plain")
    public String easterEggGET() {
        return "42";
    }
	

	@GET 
    @Produces("text/plain")
	@Path("isalie")
    public String easterEggLieGET() {
        return "NO!";
    }
	
	
	
	@PUT 
    @Produces("text/plain")
	 @Consumes("text/plain")
    public String easterEggPUT(String put) {
       
		if(!put.isEmpty())
			put = "don't try to tell me what to believe!";
			else
				put = "42";
		return put;
    }
	
	
	@DELETE
    @Produces("text/plain")
	 @Consumes("text/plain")
    public String easterEggDELETE(String put) {
       
		return "DARE YOU! YOU CAN'T DELETE THE ANSWER OF LIFE!";
    }
	
	@POST
    @Produces("text/plain")
	 @Consumes("text/plain")
    public String easterEggPOST(String put) {
       
		return "thanks for the info but its still 42...";
    }
	
	

}
