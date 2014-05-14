package nl.fontys.cryptoexchange.core;

import javax.xml.bind.annotation.XmlRootElement;

/**
 * contains all the currencies
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @created 15-Apr-2014 02:52:21
 */
@XmlRootElement
public enum Currency {
	//TODO add more currencies
	USD, BTC, LTC, XRP, ZET, PPC, DOGE, NXT, TRC;
}