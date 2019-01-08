from django.db import models

# Create your models here.
class Product(models.Model):
    name = models.CharField(max_length=50)
    price = models.CharField(max_length=100)
    photo = models.CharField(max_length=100, default="hello")
    # img = models.ImageField(upload_to=get_image_path, blank=True, null=True)
    # cdate = models.DateTimeField(auto_now_add=True)