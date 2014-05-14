package nl.fotnys.cryptoexchange.webservice;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Sample {
	
	
	
	
	private String name = "homo";
	
	private String farbe = "blau";

	
	public String getFarbe() {
		return farbe;
	}

	public void setFarbe(String farbe) {
		this.farbe = farbe;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
	@Override
	public String toString()
	{
		return farbe + "  " + name;
	}

}
