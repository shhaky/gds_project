package nl.fontys.cryptoexchange.core;

import javax.xml.bind.annotation.XmlRootElement;

/**
 * has values BID and ASK
 * <p>
 * BUY = BID buying order
 * <p>
 * SELL = ASK selling order
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @created 04-Apr-2014 14:06:44
 */
@XmlRootElement
public enum OrderType {
	BUY, SELL;

}