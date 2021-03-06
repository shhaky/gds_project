package nl.fontys.cryptoexchange.core;

import org.apache.log4j.Logger;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 16-Apr-2014 02:14 is a general Generator for IDs, and is also a
 *          Singleton
 */
public class IdGenerator {

	private static IdGenerator instance;

	public static synchronized IdGenerator getInstance() {
		if (instance == null) {
			instance = new IdGenerator();
		}
		return instance;
	}

	/**
	 * Don't use only for JUNIT test purpose!
	 */
	@Deprecated
	public void TEST_RESET() {

		instance = new IdGenerator();

	}

	/**
	 * will generate an ID
	 * 
	 * @return a unique Trade ID
	 */
	public synchronized long getTradeId() {

		if (tradeIdCount == Long.MAX_VALUE) {
			log.info("no Trade IDs left, starting @ " + TRADE_ID_START_VALUE + " again");

			this.tradeIdCount = TRADE_ID_START_VALUE;
		}

		long id = tradeIdCount;

		tradeIdCount++;

		return id;

	}

	/**
	 * will generate an ID
	 * 
	 * @return a unique Order ID
	 */
	public synchronized long getOrderId() {
		if (orderIdCount == Long.MAX_VALUE) {
			log.info("no Order IDs left, starting @ " + ORDER_ID_START_VALUE + " again");

			this.orderIdCount = ORDER_ID_START_VALUE;
		}

		long id = orderIdCount;

		orderIdCount++;

		return id;
	}

	public static final long TRADE_ID_START_VALUE = 1000000;

	public static final long ORDER_ID_START_VALUE = 1000000000;

	private IdGenerator() {

		this.tradeIdCount = TRADE_ID_START_VALUE;

		this.orderIdCount = ORDER_ID_START_VALUE;

	}

	private long tradeIdCount;

	private long orderIdCount;

	private Logger log = Logger.getLogger(IdGenerator.class);

}
