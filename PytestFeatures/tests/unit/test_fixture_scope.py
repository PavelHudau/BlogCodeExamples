import pytest


@pytest.fixture(scope="session")
def session_fixture():
    print("session_fixture setup")
    yield
    print("session_fixture teardown")


@pytest.fixture(scope="module")
def module_fixture():
    print("module_fixture setup")
    yield
    print("module_fixture teardown")


@pytest.fixture
def function_fixture():
    print("function_fixture setup")
    yield
    print("\nfunction_fixture teardown")


# Run as
# pytest -v -s tests/unit/test_fixture_scope.py
def test_fixture_scope(module_fixture, session_fixture, function_fixture):
    print(f"RUNNING : test {__name__}")
    assert True
