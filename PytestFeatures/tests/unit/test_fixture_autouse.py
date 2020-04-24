import pytest


@pytest.fixture(scope="session", autouse=True)
def session_fixture():
    print("session_fixture setup")
    yield
    print("session_fixture teardown")


@pytest.fixture(scope="module", autouse=True)
def module_fixture():
    print(f"module_fixture setup")
    yield
    print(f"module_fixture teardown")


@pytest.fixture(autouse=True)
def function_fixture():
    print("function_fixture setup")
    yield
    print("function_fixture teardown")


# Run as
# pytest -v -s tests/unit/test_fixture_scope.py
def test_fixture_scope():
    print(f"RUNNING : test {__name__}")
    # Make test fail to see the output
    assert True
