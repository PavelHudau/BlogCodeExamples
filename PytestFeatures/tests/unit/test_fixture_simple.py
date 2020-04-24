import pytest


@pytest.fixture
def simple_fixture():
    print("SETUP : simple_fixture")
    yield
    print("TEARDOWN : simple_fixture")


@pytest.mark.usefixtures("simple_fixture")
def test_fixture_with_usefixtures_attribute():
    print(f"RUNNING : test {__name__}")
    # Make test fail to see the output
    assert True


def test_fixture_as_function_parameter(simple_fixture):
    print(f"RUNNING : test {__name__}")
    # Make test fail to see the output
    assert True


@pytest.mark.parametrize(
    "param_1, param_2",
    [
        (1, 2),
        (3, 4)
    ])
def test_fixture_as_function_parameter_with_parametrized_tests(simple_fixture, param_1, param_2):
    print(f"RUNNING : test {__name__} with parameters {param_1}, {param_2}")
    # Make test fail to see the output
    assert True
