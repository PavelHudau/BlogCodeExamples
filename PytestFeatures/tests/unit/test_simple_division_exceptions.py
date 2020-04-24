import pytest

import src.division as dv


def test_divide_by_zero():
    with pytest.raises(ZeroDivisionError):
        dv.divide(2, 0)


def test_try_divide_by_zero():
    (result, is_success) = dv.try_divide(2, 0)
    assert not is_success
    assert result is None
