package nl.fontys.cryptoexchange.webservice;

import javax.ws.rs.core.MediaType;

import nl.fontys.cryptoexchange.core.Order;
import nl.fotnys.cryptoexchange.webservice.Sample;

import org.junit.Test;

import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

public class ServiceTest {

	@Test
	public void testGET() {

		Client client = Client.create();
		WebResource webResource = client.resource("http://localhost:8080/tradeengine/webresources/myresource");
		ClientResponse response = webResource.accept(MediaType.APPLICATION_JSON).get(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		Order output = response.getEntity(Order.class);
		System.out.println("Output from Server .... \n");
		System.out.println(output);

	}
	
	@Test
	public void testPUT() {

		Client client = Client.create();
		WebResource webResource = client.resource("http://localhost:8080/tradeengine/webresources/myresource");
		ClientResponse response = webResource.accept(MediaType.APPLICATION_JSON).get(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		Sample output = response.getEntity(Sample.class);
		System.out.println(output);

	
		response = webResource.accept(MediaType.APPLICATION_JSON).put(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		
		
		
	}

}
