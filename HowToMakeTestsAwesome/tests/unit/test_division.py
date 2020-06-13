import pytest
import src.division as dv


def test_division():
    # Do assert for expected value
    assert 5 == dv.divide(10, 2)


def test_division__divided_by_0__raises_exception():
    # pytest syntax to test for expected Exception
    with pytest.raises(ZeroDivisionError):
        dv.divide(10, 0)
