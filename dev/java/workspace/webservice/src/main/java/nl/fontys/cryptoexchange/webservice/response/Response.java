package nl.fontys.cryptoexchange.webservice.response;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 * 
 * @author Tobias Zobrist
 *
 *
 *	this is a basic response container for
 *
 *
 * @param <Type>
 */
@XmlRootElement
public class Response<Type> {
	
	
	
	
	public Response() {
	}
	
	
	public Response(Type attachment)
	{
		this.attachment = attachment;
		
		this.status = "unknown";
		
		this.attatchmentType =	this.attachment.getClass().getSimpleName();
		
	}
	
	
	public void setSuccsess()
	{
		this.status = "succsess";
		this.reason = "";
	}
	
	public void setFail(String reason)
	{
		this.status = "fail";
		this.reason = reason;
	}
	
	public void setStatus(String status)
	{
		this.status = status;
	}
	
	@XmlElement
	public String getStatus()
	{
		return this.status;
	}
	
	@XmlElement
	public Type getAttachment()
	{
		return this.attachment;
	}
	
	@XmlElement
	public String getAttatchmentType() {
		return attatchmentType;
	}

	@XmlElement
	public String getReason() {
		return reason;
	}
	
	
	private String status;
	
	
	private String reason;
	
	private Type attachment;
	
	private String attatchmentType;

}
