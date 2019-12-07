from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('', include('authentication_form.urls')),
    path('root/', include('root.urls')),
    path('admin/', admin.site.urls),
]
