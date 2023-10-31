# Object Pool

This implementation introduces an abstract class PoolBase<T> which is a generic object pool that can be used with objects inheriting from MonoBehaviour. Let's delve into this implementation in detail:

1. The PoolBase<T> class utilizes a generic type T, constrained to classes inheriting from MonoBehaviour. This ensures that only Unity component objects can be pooled.

2. The class features two serialized fields:

_prefab: This is the object used for creating new objects in the pool.

_initialPoolSize: The pool's initial size, determining how many objects will be created during pool initialization.

3. The pool maintains a list _pool containing objects belonging to the pool.

4. There's a virtual method Container, which returns the Transform of the container for placing the created objects. By default, it returns the transform of the component to which this pool is attached.

5. In the Awake method, which is called upon the object's start, the pool is initialized. It starts by creating _initialPoolSize objects and adds them to the _pool list. Each newly created object is deactivated.

6. The GetObjectFromPool() method is designed to obtain an object from the pool. It checks all objects in the pool and returns the first inactive object. If all objects are already active, it creates a new object and returns it.

7. The HasActiveObject() method checks if there is an active object in the pool. It iterates through all the objects in the pool and returns true if at least one object is active. Otherwise, it returns false.

8. The virtual method Instantiate() is used for creating a new object. It creates a new object, attaches it to the container, and adds it to the pool list. This method can be overridden in derived classes to cater to specific object creation needs.

This object pool implementation allows for convenient management of object activity, efficient resource utilization, and the ability to extend functionality in derived classes, which can extend the Instantiate() method or other methods for specific object creation requirements.
