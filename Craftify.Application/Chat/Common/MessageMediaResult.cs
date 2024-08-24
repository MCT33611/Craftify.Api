﻿using Craftify.Domain.Enums;

namespace Craftify.Application.Chat.Common
{
    public class MessageMediaResult
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public long FileSize { get; set; }
        public string CdnUrl { get; set; } = null!;
        public MediaType Type { get; set; }

    }
}