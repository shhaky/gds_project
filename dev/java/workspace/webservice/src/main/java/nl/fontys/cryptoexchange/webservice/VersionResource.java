package nl.fontys.cryptoexchange.webservice;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;

@Path("version")
public class VersionResource {

	
	@GET 
    @Produces("text/plain")
    public String getVersion() {
    	
    	return TradeEngineHolder.getTradeEngine().getVersion();
    }
	
	
}
