package nl.fontys.cryptoexchange.webservice;

import static org.junit.Assert.assertEquals;

import javax.ws.rs.core.MediaType;

import org.junit.Test;

import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

public class MarketResourceTest {

	private static final String RESOURCE_ROOT = WebRoot.SERVICE_ROOT + "market";
	
	
	@Test
	public void testCreateMarketPUT() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT+"/create");
		ClientResponse response = webResource.accept(MediaType.APPLICATION_JSON).put(ClientResponse.class,"zet/btc");
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		
		assertEquals("{\"reason\":\"\",\"status\":\"succsess\"}", output);;
}
	
	
	@Test
	public void testRemoveMarketPUT() {
		
		this.testCreateMarketPUT();
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT+"/remove");
		ClientResponse response = webResource.accept(MediaType.APPLICATION_JSON).put(ClientResponse.class,"zet/btc");
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		
		assertEquals("{\"reason\":\"\",\"status\":\"succsess\"}", output);;
}
	
}
