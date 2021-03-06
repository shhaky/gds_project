package nl.fontys.cryptoexchange.core;

import static org.junit.Assert.assertEquals;

import java.util.Calendar;
import java.lang.Runnable;

import nl.fontys.cryptoexchange.core.IdGenerator;

import org.apache.log4j.Logger;
import org.junit.Before;
import org.junit.Test;

/**
 * @author Tobias Zobrist will test the class
 *         nl.fontys.cyrptoexchange.engine.IdGenerator it will test the thread
 *         safety of the IdGenerator
 */
public class IdGeneratorTest {

	@Before
	public void setUp() throws Exception {
		threadAgentHolderTrade = new Thread[NUMBER_OF_THREADS];
		threadAgentHolderOrder = new Thread[NUMBER_OF_THREADS];

		for (int i = 0; i < NUMBER_OF_THREADS; i++) {
			threadAgentHolderTrade[i] = new Thread(new IdGeneratorTestAgent(NUMBER_OF_ID_REQUESTS, IdGeneratorTestAgent.TRADE));
			threadAgentHolderOrder[i] = new Thread(new IdGeneratorTestAgent(NUMBER_OF_ID_REQUESTS, IdGeneratorTestAgent.ORDER));
		}

	}

	@SuppressWarnings("deprecation")
	@Before
	public void resetSingleton() {

		IdGenerator.getInstance().TEST_RESET();
	}

	@Test
	public void testThreadSafetyTradeIDs() throws InterruptedException {

		long startTime = Calendar.getInstance().getTimeInMillis();

		for (int i = 0; i < NUMBER_OF_THREADS; i++)
			threadAgentHolderTrade[i].start();

		for (int i = 0; i < NUMBER_OF_THREADS; i++)
			threadAgentHolderTrade[i].join();

		long finalTime = Calendar.getInstance().getTimeInMillis() - startTime;

		log.info("generated " + IdGenerator.TRADE_ID_START_VALUE + NUMBER_OF_THREADS * NUMBER_OF_ID_REQUESTS + " Trade IDs in " + finalTime + "ms with "
						+ NUMBER_OF_THREADS + " Threads");

		// threads times their requests plus the starting value should equals the current ID

		assertEquals(IdGenerator.TRADE_ID_START_VALUE + NUMBER_OF_THREADS * NUMBER_OF_ID_REQUESTS, IdGenerator.getInstance().getTradeId());

	}

	@Test
	public void testThreadSafetyOrderIDs() throws InterruptedException {
		long startTime = Calendar.getInstance().getTimeInMillis();

		for (int i = 0; i < NUMBER_OF_THREADS; i++)
			threadAgentHolderOrder[i].start();

		for (int i = 0; i < NUMBER_OF_THREADS; i++)
			threadAgentHolderOrder[i].join();

		// threads times their requests plus the starting value should equals the current ID
		long finalTime = Calendar.getInstance().getTimeInMillis() - startTime;
		log.info("generated " + IdGenerator.TRADE_ID_START_VALUE + NUMBER_OF_THREADS * NUMBER_OF_ID_REQUESTS + " Order IDs in " + finalTime + "ms with "
						+ NUMBER_OF_THREADS + " Threads");

		assertEquals(IdGenerator.ORDER_ID_START_VALUE + NUMBER_OF_THREADS * NUMBER_OF_ID_REQUESTS, IdGenerator.getInstance().getOrderId());

	}

	private final static int NUMBER_OF_THREADS = 200;

	private final static int NUMBER_OF_ID_REQUESTS = 200000;

	private Logger log = Logger.getLogger(IdGeneratorTest.class);

	private Thread[] threadAgentHolderTrade;

	private Thread[] threadAgentHolderOrder;

}

/**
 * @author Tobias Zobrist this Agent will request Order IDs and Trade IDs.
 */
class IdGeneratorTestAgent implements Runnable {
	public static int TRADE = 0;

	public static int ORDER = 1;

	public IdGeneratorTestAgent(final int idRequests, int type) {
		this.idRequests = idRequests;
		this.type = type;
	}
	
	@Override
	public void run() {

		for (int i = 0; i < idRequests; i++) {
			if (type == TRADE) {
				IdGenerator.getInstance().getTradeId();
			} else if (type == ORDER) {
				IdGenerator.getInstance().getOrderId();

			}

		}

	}

	private int type;

	private int idRequests;

	

}
