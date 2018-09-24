using System;
using System.Collections.Generic;
using System.IO;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class EditProjectParameters
    {
        public String Name { get; set; }

        public String[] Languages { get; set; }

        [Property("join_policy")]
        public ProjectJoinPolicy? JoinPolicy { get; set; }

        [Property("language_access_policy")]
        public LanguageAccessPolicy? LanguageAccessPolicy { get; set; }

        [Property("hide_duplicates")]
        public DuplicatesOption? Duplicates { get; set; }

        [Property("export_translated_only")]
        public Boolean? ExportTranslatedOnly { get; set; }

        [Property("export_approved_only")]
        public Boolean? ExportApprovedOnly { get; set; }

        [Property("auto_translate_dialects")]
        public Boolean? AutoTranslateDialects { get; set; }

        [Property("public_downloads")]
        public Boolean? PublicDownloads { get; set; }

        [Property("use_global_tm")]
        public Boolean? UseGlobalTM { get; set; }

        public FileInfo Logo { get; set; }

        public String CName { get; set; }

        public String Description { get; set; }

        [Property("qa_checks")]
        public IDictionary<String, Boolean> QaChecks { get; set; }

        [Property("webhook_file_translated")]
        public Uri WebhookFileTranslated { get; set; }

        [Property("webhook_file_proofread")]
        public Uri WebhookFileProofread { get; set; }

        [Property("webhook_project_translated")]
        public Uri WebhookProjectTranslated { get; set; }

        [Property("webhook_project_proofread")]
        public Uri WebhookProjectProofread { get; set; }
    }
}
