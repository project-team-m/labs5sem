from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('', include('authentication_form.urls')),
    path('articles/', include('articles.urls')),
    path('grappelli/', include('grappelli.urls')),
    path('admin/', admin.site.urls),
]