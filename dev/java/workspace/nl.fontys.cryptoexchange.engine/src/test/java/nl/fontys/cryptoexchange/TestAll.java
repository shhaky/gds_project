package nl.fontys.cryptoexchange;

import nl.fontys.cryptoexchange.core.TestCoreAll;
import nl.fontys.cryptoexchange.engine.TestEngineAll;
import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.junit.runners.Suite.SuiteClasses;

/**
 * @author Tobias Zobrist this will run all the Test Cases
 */

@RunWith(Suite.class)
@SuiteClasses({ TestCoreAll.class, TestEngineAll.class, })
public class TestAll {

}
