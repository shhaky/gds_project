package nl.fontys.cryptoexchange.core;

import nl.fontys.cryptoexchange.core.IdGeneratorTest;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.TradeTest;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.junit.runners.Suite.SuiteClasses;

/**
 * @author Tobias Zobrist this will run all the Core Test Cases
 */

@RunWith(Suite.class)
@SuiteClasses({ OrderTest.class, CurrencyPairTest.class, TradeTest.class, IdGeneratorTest.class, })
public class TestCoreAll {

}
