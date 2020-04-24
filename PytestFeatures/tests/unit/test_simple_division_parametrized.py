import pytest

import src.division as dv


@pytest.mark.parametrize(
    "dividend, divisor, expected_result",
    [
        # (dividend, divisor, expected_result)
        (6, 3, 2), # <- Test case 1
        (-6, 3, -2), # <- Test case 2
        (6, -3, -2), # <- Test case 3
        (-6, -3, 2), # <- Test case 4
        (0, 3, 0), # <- Test case 5
    ])
def test_divide(dividend, divisor, expected_result):
    assert expected_result == dv.divide(dividend, divisor)
