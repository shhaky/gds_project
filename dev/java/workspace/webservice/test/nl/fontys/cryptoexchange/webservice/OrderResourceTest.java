package nl.fontys.cryptoexchange.webservice;

import static org.junit.Assert.assertEquals;

import javax.ws.rs.core.MediaType;

import nl.fontys.cryptoexchange.core.OrderTest;

import org.junit.Test;

import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

public class OrderResourceTest {
	private static final String RESOURCE_ROOT = WebRoot.SERVICE_ROOT + "order";
	
	@Test
	public void testPlaceOrderPUT() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT+"/create");
		ClientResponse response = webResource.accept(MediaType.APPLICATION_JSON).put(ClientResponse.class,OrderTest.ORDER_BUY_HIGH_USER1);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		
		assertEquals("{\"reason\":\"\",\"status\":\"succsess\"}", output);;
}
	
}
