package nl.fontys.cryptoexchange.webservice;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

public class VersionResourceTest {
	
	
	@Test
	public void testVersionGET() {
		Client client = Client.create();
		WebResource webResource = client.resource(WebRoot.SERVICE_ROOT + "version");
		ClientResponse response = webResource.accept("text/plain").get(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		assertEquals(TradeEngineHolder.getTradeEngine().getVersion(), output);
}
}
