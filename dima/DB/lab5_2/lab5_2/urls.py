from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('', include('authentication_form.urls')),
    path('admin-user/', include('admin_user1.urls')),
    path('admin/', admin.site.urls),
]
