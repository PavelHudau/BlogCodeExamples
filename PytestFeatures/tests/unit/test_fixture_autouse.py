import pytest


@pytest.fixture(scope="session", autouse=True)
def session_fixture():
    print("session_fixture setup")
    yield
    print("session_fixture teardown")


@pytest.fixture(scope="module", autouse=True)
def module_fixture():
    print("module_fixture setup")
    yield
    print("module_fixture teardown")


@pytest.fixture(autouse=True)
def function_fixture():
    print("function_fixture setup")
    yield
    print("\nfunction_fixture teardown")


def test_fixture_scope():
    print(f"RUNNING : test {__name__}")
    assert True
