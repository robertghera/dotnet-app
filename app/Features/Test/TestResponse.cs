﻿using System.ComponentModel.DataAnnotations;

namespace app.Features.Test;

public class TestResponse
{
    public string Id { get; set; }
    public string Subject { get; set; }
    public DateTime TestDate { get; set; }
}