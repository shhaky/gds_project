package nl.fontys.cryptoexchange.webservice;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

public class EasterEggResourceTest {

	private static final String RESOURCE_ROOT = WebRoot.SERVICE_ROOT + "theansweroflife";
	
	@Test
	public void testEasterEggGET() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT);
		
		ClientResponse response = webResource.accept("text/plain").get(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		assertEquals("42", output);
}
	
	@Test
	public void testEasterEggPUT() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT);
		ClientResponse response = webResource.accept("text/plain").put(ClientResponse.class,"its 43");
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		assertEquals("don't try to tell me what to believe!", output);
}
	@Test
	public void testEasterEggPUTv2() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT);
		ClientResponse response = webResource.accept("text/plain").put(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		assertEquals("42", output);
}
	
	@Test
	public void testEasterEggDELETE() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT);
		ClientResponse response = webResource.accept("text/plain").delete(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		assertEquals("DARE YOU! YOU CAN'T DELETE THE ANSWER OF LIFE!", output);
}
	@Test
	public void testEasterEggPOST() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT);
		ClientResponse response = webResource.accept("text/plain").post(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		assertEquals("thanks for the info but its still 42...", output);
}
	@Test
	public void testEasterEggIsALieGET() {
		Client client = Client.create();
		WebResource webResource = client.resource(RESOURCE_ROOT + "/isalie");
		ClientResponse response = webResource.accept("text/plain").get(ClientResponse.class);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		String output = response.getEntity(String.class);
		assertEquals("NO!", output);
}
}
