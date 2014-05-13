package nl.fontys.cryptoexchange.engine;

import java.util.List;

import org.apache.log4j.Logger;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.Trade;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;
import nl.fontys.cryptoexchange.engine.exception.UnableToDeleteOrderException;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 12-May-2014 01:58
 *          <p>
 *          This Class is an extension of the traditional TradeEngine. This
 *          additional Layer has the purpose to reduce Server processing time in
 *          a time of many requests if there is a GET request for public info it
 *          wont calculate them over and over again, this class stores temporary
 *          all market data and refreshes them every updateIntervall.
 */

public class TradeEngineAutoUpdating extends TradeEngineManualUpdating implements Runnable {

	public TradeEngineAutoUpdating(long updateIntervallInMilliseconds) {

		this.setUpdateIntervall(updateIntervallInMilliseconds);

		this.updaterThread = new Thread(this);
		this.updaterThread.start();

	}

	private Logger log = Logger.getLogger(TradeEngineAutoUpdating.class);

	private long updateIntervall;

	private Thread updaterThread;

	@Override
	public List<Order> getBidDepth(CurrencyPair pair) throws MarketNotAvailableException {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Order> getAskDepth(CurrencyPair pair) throws MarketNotAvailableException {

		return null;
	}

	@Override
	public String getAskDepthAsJSON(CurrencyPair market) throws MarketNotAvailableException {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String getBidDepthAsJSON(CurrencyPair market) throws MarketNotAvailableException {
		// TODO Auto-generated method stub
		return null;
	}

	public long getUpdateIntervall() {
		return updateIntervall;
	}

	public void setUpdateIntervall(long updateIntervall) {
		this.updateIntervall = updateIntervall;
	}

	@Override
	public void run() {

	}

}
