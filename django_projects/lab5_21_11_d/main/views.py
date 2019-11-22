from django.shortcuts import render
from django.http import HttpResponse


def send_main(request):
    return HttpResponse("Hello, world. You're at the polls index.")
